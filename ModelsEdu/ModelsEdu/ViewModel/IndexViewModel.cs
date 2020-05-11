using ModelsEdu.Models;
using System;
using System.Collections.Generic;

namespace ModelsEdu.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<CompanyModel> Companies { get; set; }
        public IndexViewModel(IEnumerable<Phone> phonelist, IEnumerable<CompanyModel> companylist)
        {
            Phones = phonelist;
            Companies = companylist;
        }
    }
}
