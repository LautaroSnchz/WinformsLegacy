using System;
using System.Windows.Forms;

namespace winformsContactsnetviejo
{
    public partial class ContactDetails : Form
    {
        private BusinessLogicLayer _businessLogicLayer;
        private Contact _contact; // nulo si es “nuevo”, con datos si es “editar”

        public ContactDetails()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveContact();

            // refresca la grilla del formulario dueño (si lo abriste con ShowDialog(this))
            if (this.Owner is Main owner)
                owner.PopulateContacts();

            this.Close();
        }

        private void SaveContact()
        {
            Contact contact = new Contact();
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Phone = txtPhone.Text;
            contact.Address = txtAddress.Text;

            contact.Id = _contact != null ? _contact.Id : 0;

            _businessLogicLayer.SaveContact(contact);

     

           
        }

        public void LoadContact(Contact contact)
        {
            _contact = contact;
            if (contact != null) 
            {
                ClearForm();

                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtPhone.Text = contact.Phone;
                txtAddress.Text = contact.Address;
            }
            else
            {
                
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private void txtAddress_TextChanged(object sender, EventArgs e) { }
        private void txtFirstName_TextChanged(object sender, EventArgs e) { }
    }
}
