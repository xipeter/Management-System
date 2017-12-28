using System;
using System.Runtime.InteropServices;

namespace Neusoft.FrameWork.WinForms.Controls
{
	#region CollapsiblePanelCollection class
	/// <summary>
	/// Summary description for CollapsiblePanelCollection.
	/// </summary>
	public class CollapsiblePanelCollection : System.Collections.CollectionBase
	{
		#region Public Constructors
		/// <summary>
		/// Initialises a new instance of <see cref="CollapsiblePanelCollection">CollapsiblePanelCollection</see>.
		/// </summary>
		public CollapsiblePanelCollection()
		{
            
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds a <see cref="CollapsiblePanel">CollapsiblePanel</see> to the end of the collection.
		/// </summary>
		/// <param name="panel">The <see cref="CollapsiblePanel">CollapsiblePanel</see> to add.</param>
		public void Add(CollapsiblePanel panel)
		{
			this.List.Add(panel);
		}

		/// <summary>
		/// Removes the <see cref="CollapsiblePanel">CollapsiblePanel</see> from the collection at the specified index.
		/// </summary>
		/// <param name="index">The index of the <see cref="CollapsiblePanel">CollapsiblePanel</see> to remove.</param>
		public void Remove(int index)
		{
			// Ensure the supplied index is valid
			if((index >= this.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("The supplied index is out of range");
			}
			this.List.RemoveAt(index);
		}

		/// <summary>
		/// Gets a reference to the <see cref="CollapsiblePanel">CollapsiblePanel</see> at the specified index.
		/// </summary>
		/// <param name="index">The index of the <see cref="CollapsiblePanel">CollapsiblePanel</see> to retrieve.</param>
		/// <returns></returns>
		public CollapsiblePanel Item(int index)
		{
			// Ensure the supplied index is valid
			if((index >= this.Count) || (index < 0))
			{
				throw new IndexOutOfRangeException("The supplied index is out of range");
			}
			return (CollapsiblePanel)this.List[index];
		}

		/// <summary>
		/// Inserts a <see cref="CollapsiblePanel">CollapsiblePanel</see> at the specified position.
		/// </summary>
		/// <param name="index">The zero-based index at which <i>panel</i> should be inserted.</param>
		/// <param name="panel">The <see cref="CollapsiblePanel">CollapsiblePanel</see> to insert into the collection.</param>
		public void Insert(int index, CollapsiblePanel panel)
		{
			this.List.Insert(index, panel);
		}

		/// <summary>
		/// Copies the elements of the collection to a <see cref="System.Array">System.Array</see>, starting at a particular index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="System.Array">System.Array</see> that is the destination of the elements. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in <i>array</i> at which copying begins.</param>
		public void CopyTo(System.Array array, System.Int32 index)
		{
			this.List.CopyTo(array, index);
		}

		/// <summary>
		/// Searches for the specified <see cref="CollapsiblePanel">CollapsiblePanel</see> and returns the zero-based index of the first occurrence.
		/// </summary>
		/// <param name="panel">The <see cref="CollapsiblePanel">CollapsiblePanel</see> to search for.</param>
		/// <returns></returns>
		public int IndexOf(CollapsiblePanel panel)
		{
			return this.List.IndexOf(panel);
		}
		#endregion
	}
	#endregion
}
