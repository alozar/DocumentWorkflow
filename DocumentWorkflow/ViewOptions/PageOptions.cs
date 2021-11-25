using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentWorkflow.ViewOptions
{
    public class PageOptions
    {
        public int CurrentPage { get; set; } //Текущая страница
        public int TotalPages { get; set; }  //Всего страниц
        public int SizePage { get; set; }    //Количество строк на странице

        public int TotalRows { get; set; }   //Всего строк
        public int Rows { get; set; }

        public PageOptions()
        {
            CurrentPage = 1;
            SizePage = 25;
        }
    }
}
