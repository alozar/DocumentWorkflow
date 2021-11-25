using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentWorkflow.Models.Documents.Statuses
{
    public enum StatusEnum
    {
        Registered = 0, //зарегистрирован - документ создан, доступен для редактирования
        Work = 1,       //в работе - документ зафиксирован и не подлежит редактированию
        Archive = 2,    //в архиве - документ перемещен в архив и не показывается в общем реестре
        Signature = 3,  //на подпись - доступно для редактирования только поле "подписант"
        Sented = 4      //отправлен - документ зафиксирован и не подлежит редактированию
    }
}
