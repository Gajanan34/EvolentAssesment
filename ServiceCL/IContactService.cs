using EntitiesCL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL
{
    public interface IContactService
    {
        IEnumerable<Contact> getAllContacts();
        bool AddContact(Contact contact);
        bool EditContact(Contact contact);
        Contact GetContact(int id);

        bool DeleteContact(int id);
    }
}
