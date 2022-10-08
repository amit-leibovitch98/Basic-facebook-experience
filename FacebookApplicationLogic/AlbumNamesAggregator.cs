using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;

namespace FacebookApplicationLogic
{
    public class AlbumNamesAggregator : IAggregator
    {
        private LoginResult m_LoginResult;

        public AlbumNamesAggregator(LoginResult i_LoginResult)
        {
            m_LoginResult = i_LoginResult;
        }

        public IIterator GetIterator()
        {
            return new AlbumNamesIterator(m_LoginResult);
        }
    }
}
