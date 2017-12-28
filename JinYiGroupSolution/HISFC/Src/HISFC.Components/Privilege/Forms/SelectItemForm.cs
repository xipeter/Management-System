using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.Privilege.WinForms.Forms
{
    public partial class SelectItemForm<T> : InputBaseForm
    {
        public SelectItemForm()
        {
            InitializeComponent();            
            this.InitDataSet();

            ///输入框操作事件
            this.txtInput.TextChanged += new EventHandler(txtInput_TextChanged);
            this.txtInput.KeyDown += new KeyEventHandler(txtInput_KeyDown);
            
            this.chbSelect.CheckedChanged += new EventHandler(chbSelect_CheckedChanged);

            this.fpSpread1.KeyDown += new KeyEventHandler(fpSpread1_KeyDown);
            this.fpSpread1.CellDoubleClick += new FarPoint.Win.Spread.CellClickEventHandler(fpSpread1_CellDoubleClick);

        }

        void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }       

        void fpSpread1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.fpSpread1_Sheet1.RowCount == 0) return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void chbSelect_CheckedChanged(object sender, EventArgs e)
        {
            this.txtInput.Focus();
            this.txtInput.SelectAll();
        }


        void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            //上箭头选择上一条记录
            if (e.KeyCode == Keys.Up)
            {
                if (this.fpSpread1_Sheet1.ActiveRowIndex > 0)
                {
                    this.fpSpread1_Sheet1.ActiveRowIndex--;
                    this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 4);
                    return;
                }
            }

            //下箭头选择下一条记录
            if (e.KeyCode == Keys.Down)
            {
                if (this.fpSpread1_Sheet1.ActiveRowIndex < this.fpSpread1_Sheet1.RowCount - 1)
                {
                    this.fpSpread1_Sheet1.ActiveRowIndex++;
                    this.fpSpread1_Sheet1.AddSelection(this.fpSpread1_Sheet1.ActiveRowIndex, 0, 1, 4);
                    return;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (this.fpSpread1_Sheet1.RowCount == 0) return;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (e.KeyCode == Keys.Cancel)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }
        }

        /// <summary>
        /// 检索条目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txtInput_TextChanged(object sender, EventArgs e)
        {
            string _key = this.txtInput.Text.Trim();
            _key = NFC.Public.String.TakeOffSpecialChar(_key);

            if (this.IsSimilar)
                _key = "%" + _key + "%";
            else
                _key = _key + "%";

            string _filter = "";
            //查询全部
            if (_key == "%" || _key == "%%")
            {
                _filter = "编码 like '%'";
            }
            else
            {
                _filter = "(拼音码 LIKE '" + _key + "') OR " +
                        "(助记码 LIKE '" + _key + "') OR " +
                        "(编码 LIKE '" + _key + "') OR " +
                        "(名称 LIKE '" + _key + "')";
            }

            _dvItems.RowFilter = _filter;
            this.AddItemToFp();

            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                this.fpSpread1_Sheet1.AddSelection(0, 0, 1, 4);
            }
        }

        private IList<T> _items;
        private DataSet _dsItems;
        private DataView _dvItems;
        private string _id = "ID";
        private string _secondKey;
        private string _name = "Name";
        private string _description;
        private string _input;

        /// <summary>
        /// id列
        /// </summary>
        public string ID
        {
            set { _id = value; }
        }

        /// <summary>
        /// 第二主键
        /// </summary>
        public string SecondKey
        {
            set { _secondKey = value; }
        }

        /// <summary>
        /// name列
        /// </summary>
        public string Value
        {
            set { _name = value; }
        }
        /// <summary>
        /// 助记码列
        /// </summary>
        public string Input
        {
            set { _input = value; }
        }
        /// <summary>
        /// 备注列
        /// </summary>
        public string Description
        {
            set { _description = value; }
        }

        /// <summary>
        /// 选择项目
        /// </summary>
        public T SelectedItem
        {
            get
            {
                if (this.fpSpread1_Sheet1.RowCount == 0) return default(T);

                string _firValue = this.fpSpread1_Sheet1.GetText(this.fpSpread1_Sheet1.ActiveRowIndex, 0);
                string _secValue = toString(this.fpSpread1_Sheet1.GetTag(this.fpSpread1_Sheet1.ActiveRowIndex, 0));

                foreach (T _item in _items)
                {
                    if (string.IsNullOrEmpty(_secondKey))
                    {
                        if (toString(typeof(T).GetProperty(_id).GetValue(_item, null)) == _firValue)
                            return _item;
                    }
                    else
                    {
                        if (toString(typeof(T).GetProperty(_id).GetValue(_item, null)) == _firValue &&
                            toString(typeof(T).GetProperty(_secondKey).GetValue(_item, null)) == _secValue)
                            return _item;
                    }
                }

                return default(T);
            }
        }
        /// <summary>
        /// 是否模糊查询
        /// </summary>
        public bool IsSimilar
        {
            get { return this.chbSelect.Checked; }
            set { this.chbSelect.Checked = value; }
        }

        private void InitDataSet()
        {
            _dsItems = new DataSet();
            _dsItems.Tables.Add();

            //定义类型
            System.Type dtStr = System.Type.GetType("System.String");

            //在myDataTable中添加列
            this._dsItems.Tables[0].Columns.AddRange(new DataColumn[] {
																			new DataColumn("编码",     dtStr),
																			new DataColumn("名称",     dtStr),
                                                                            new DataColumn("助记码",   dtStr),
																			new DataColumn("其他",     dtStr),                                                                            
																			new DataColumn("拼音码",   dtStr),
																			new DataColumn("SecondKey",   dtStr)																			
																		});
            this._dvItems = new DataView(_dsItems.Tables[0]);
        }

        public void InitItem(IList<T> items)
        {
            string _idValue, _nameValue, _descValue = "", _inputValue = "", _spellValue, _secondValue = "";

            _items = items;
            foreach (T _item in _items)
            {
                _idValue = toString(typeof(T).GetProperty(_id).GetValue(_item, null));
                _nameValue = toString(typeof(T).GetProperty(_name).GetValue(_item, null));
                if (!string.IsNullOrEmpty(_input))
                {
                    _inputValue = toString(typeof(T).GetProperty(_input).GetValue(_item, null));
                }
                if (!string.IsNullOrEmpty(_description))
                {
                    _descValue = toString(typeof(T).GetProperty(_description).GetValue(_item, null));
                }

                if (!string.IsNullOrEmpty(_secondKey))
                {
                    _secondValue = toString(typeof(T).GetProperty(_secondKey).GetValue(_item, null));
                }

                _spellValue = NFC.Public.String.GetSpell(_nameValue);

                this._dsItems.Tables[0].Rows.Add(new object[] {
																		_idValue,    //编码
																		_nameValue,  //名称
                                                                        _inputValue, //自定义码	
																		_descValue,  //其他                                                                        
																		_spellValue, //拼音码		
																		_secondValue    //tag																				
																	});
            }

            this.AddItemToFp();
        }

        private void AddItemToFp()
        {
            if(this.fpSpread1_Sheet1.RowCount>0)
                this.fpSpread1_Sheet1.Rows.Remove(0,this.fpSpread1_Sheet1.RowCount);

            for (int i = 0; i < _dvItems.Count; i++)
            {
                this.fpSpread1_Sheet1.Rows.Add(this.fpSpread1_Sheet1.RowCount, 1);

                this.fpSpread1_Sheet1.SetValue(i, 0, toString(_dvItems[i][0]));
                this.fpSpread1_Sheet1.SetValue(i, 1, toString(_dvItems[i][1]));
                this.fpSpread1_Sheet1.SetValue(i, 2, toString(_dvItems[i][2]));
                this.fpSpread1_Sheet1.SetValue(i, 3, toString(_dvItems[i][3]));

                this.fpSpread1_Sheet1.SetTag(i, 0, toString(_dvItems[i][5]));
            }

            if (this.fpSpread1_Sheet1.RowCount > 0)
            {
                this.fpSpread1_Sheet1.ActiveRowIndex = 0;
                this.fpSpread1_Sheet1.AddSelection(0, 0, 1, 4);
            }
        }

        private string toString(object obj)
        {
            if (obj == null) return "";

            return obj.ToString();
        }

        
    }    
}

