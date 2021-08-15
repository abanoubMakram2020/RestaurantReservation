using System.Collections.Generic;

namespace SharedKernal.Core.PagingModule
{
    public class Search
    {
        public List<SearchColumn> SearchColumns { get; set; }
        public string SearchText { get; set; }
    }
}
