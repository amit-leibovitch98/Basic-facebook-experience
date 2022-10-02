using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    public interface IIterator
    {
        bool MoveNext();

        object Current { get; }

        void Reset();
    }

    public class AlbumNamesIterator : IIterator
    {
        private LoginResult m_Agregate;
        private int m_CurrentIdx = -1;
        private int m_Count = -1;

        public AlbumNamesIterator(LoginResult i_Collection)
        {
            m_Agregate = i_Collection;
            m_Count = m_Agregate.LoggedInUser.Albums.Count;
        }

        public void Reset()
        {
            m_CurrentIdx = -1;
        }

        public bool MoveNext()
        {
            if (m_Count != m_Agregate.LoggedInUser.Albums.Count)
            {
                throw new Exception("Collection can not be changed during iteration!");
            }
            if (m_CurrentIdx >= m_Count)
            {
                throw new Exception("Already reached the end of the collection");
            }

            return ++m_CurrentIdx < m_Agregate.LoggedInUser.Albums.Count;
        }

        public object Current
        {
            get { return m_Agregate.LoggedInUser.Albums[m_CurrentIdx].Name; }
        }
    }
}
