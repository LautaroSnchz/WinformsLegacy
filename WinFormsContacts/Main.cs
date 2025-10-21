using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsContacts
{
    public partial class Main : Form
    {
        BussinesLogicLayer _bussinesLogicLayer;
        public Main()
        {
            InitializeComponent();
            _bussinesLogicLayer = new BussinesLogicLayer();
        }
        #region EVENTS
        private void Main_Load(object sender, EventArgs e)
        {
            PopulateContact();
        }

        private void gridContacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = (DataGridViewCell)gridContacts.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value.ToString() == "Edit")
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
            else if (cell.Value.ToString() == "Delete")
            {


                DeleteContact(int.Parse(gridContacts.Rows[e.RowIndex].Cells[0].Value.ToString()));
                PopulateContact();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenContactDetailsDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateContact(txtSearch.Text);
            txtSearch.Text = string.Empty;
        }
        #endregion

        #region PRIVATE METHODS
        private void OpenContactDetailsDialog ()
        {
            ContactDetails contactDetails = new ContactDetails();
            contactDetails.ShowDialog(this);
        }

        private void DeleteContact(int id)
        {
            _bussinesLogicLayer.DeleteContact(id);

        }
        #endregion

        #region PUBLIC METHODS

        public void PopulateContact(string searchText = null)
        {
            List<Contact> contacts = _bussinesLogicLayer.GetContacts(searchText);
            gridContacts.DataSource = contacts;
        }
        #endregion





    }
}
