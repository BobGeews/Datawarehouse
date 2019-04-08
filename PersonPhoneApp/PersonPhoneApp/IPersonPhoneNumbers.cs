using System;
using System.Collections.Generic;
using System.Text;

namespace PersonPhoneApp
{
    public interface IPersonPhoneNumbers
    {
        //CRUD
        void Create(Phone phone);
        List<Phone> ReadAll();
        void Update(long id, Phone phone);
        void Delete(long id);
        Phone ReadById(long id);


    }
}
