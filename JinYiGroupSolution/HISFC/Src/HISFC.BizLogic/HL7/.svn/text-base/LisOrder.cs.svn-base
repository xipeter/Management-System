using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Neusoft.HISFC.BizLogic.HL7
{
    public class LisOrder : ILis, IDisposable
    {
        public LisOrder()
        {
            if (this.dataManager.con.State == ConnectionState.Closed)
            {                
                System.Data.OracleClient.OracleConnectionStringBuilder ooo = new System.Data.OracleClient.OracleConnectionStringBuilder();
                ooo.UserID = "newhis45";
                ooo.Password = "his";
                ooo.DataSource = "chcc";
                this.dataManager.con.ConnectionString = ooo.ToString();

                this.dataManager.con.Open();
            }
        }

        // Track whether Dispose has been called.
        private bool disposed;

        private LisManagment dataManager = new LisManagment();
        private NHapi.Base.Parser.PipeParser parser = new NHapi.Base.Parser.PipeParser();

        #region ILis 成员

        public int PlaceOrder(Neusoft.HISFC.Models.Order.Order order)
        {
            NHapi.Model.V231.Message.ORM_O01 orm = MessageFactory.ProduceORM_O01(order);
            string message = this.parser.encode(orm);
            this.dataManager.InsertOrder(message);
            return 0;
        }

        public int PlaceOrder(ICollection<Neusoft.HISFC.Models.Order.Order> orders)
        {
            return 0;
        }

        public bool CheckOrder(Neusoft.HISFC.Models.Order.Order order)
        {
            return true;
        }

        public int SetPatient(Neusoft.HISFC.Models.RADT.PatientInfo patientInfo)
        {
            return 0;
        }

        public int Commit()
        {
            return 0;
        }

        public int Rollback()
        {
            return 0;
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);

        }

        #endregion

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    this.dataManager.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                

                // Note disposing has been done.
                disposed = true;

            }
        }

    }
}
