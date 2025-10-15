using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace winformsContactsnetviejo
{
    public partial class Main : Form
    {


        private BusinessLogicLayer _businessLogicLayer;


        public Main()
        {
            InitializeComponent();
            _businessLogicLayer = new BusinessLogicLayer();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContacts();
        }

        private void OpenContactDetailsDialog()
        {
            var dlg = new ContactDetails();
            dlg.ShowDialog(this);
        }

        public void PopulateContacts()
        {
            List<Contact> contacts = _businessLogicLayer.GetContacts();
            gridContacts.DataSource = contacts;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }

        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewLinkCell cell = (DataGridViewLinkCell)gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex]; 

            if(cell.Value.ToString() == "Edit")
            {
                ContactDetails contactDetails = new ContactDetails();
                contactDetails.LoadContact(new Contact
                {
                    Id = int.Parse(gridContacts.Rows[e.RowIndex].Cells[0].Value.ToString()),
                    FirstName = gridContacts.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    LastName = gridContacts.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Phone = gridContacts.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Address = gridContacts.Rows[e.RowIndex].Cells[4].Value.ToString()
                });
                contactDetails.ShowDialog(this);
            }
        }
    }
}

