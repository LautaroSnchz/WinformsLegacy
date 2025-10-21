using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsContacts
{
    public class BussinesLogicLayer
    {
        private DataAccesLayer _dataAccesLayer;

        public BussinesLogicLayer()
        {
            _dataAccesLayer = new DataAccesLayer();
        }

        public Contact SaveContact (Contact contact)
        {
            if (contact.Id == 0)
                _dataAccesLayer.InsertContact(contact);
            else
                _dataAccesLayer.UpdateContact(contact);
            
            return contact;
        }

        public List<Contact> GetContacts(string searchText = null)
        {
            return _dataAccesLayer.GetContacts(searchText);
        }

        public void DeleteContact(int id)
        {
            _dataAccesLayer.DeleteContact(id);
            }
    }
}
