using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardy
{
    public class UndoRedoHelper<T>
    {
        private static readonly int MAX_UNDO_ITEMS = 20;
        private static readonly int MAX_REDO_ITEMS = 20;
        private List<T> DataUndo = new List<T>();
        private List<T> DataRedo = new List<T>();
        public bool AreUndoItems
        {
            get { return DataUndo.Any(); }
        }

        public bool AreRedoItems
        {
            get { return DataRedo.Any(); }
        }

        public bool CanRedo
        {
            get;
            private set;
        }

        public UndoRedoHelper()
        {
        }

        public void PushUndo(T data)
        {
            DataUndo.Add(data);
            CanRedo = false;
            if (DataUndo.Count() > MAX_UNDO_ITEMS)
                DataUndo.Remove(DataUndo.First());
        }

        public T PopUndo()
        {
            T ret = DataUndo.Last();
            DataUndo.Remove(ret);
            CanRedo = true;
            return ret;
        }

        public void PushRedo(T data)
        {
            DataRedo.Add(data);
            if (DataRedo.Count() > MAX_REDO_ITEMS)
                DataRedo.Remove(DataUndo.First());
        }

        public T PopRedo()
        {
            T ret = DataRedo.Last();
            DataRedo.Remove(ret);
            return ret;
        }
    }
}
