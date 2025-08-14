using AutoTimeTableGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTimetableGenerator.Forms.CofigurationForms
{
    public partial class frmRoom : Form
    {
        public frmRoom()
        {
            InitializeComponent();
        }

        private void txtCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void FillGrid(string searchString)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchString.Trim()))
                {
                    query = "select RoomID [ID],RoomNo [Room],Capacity, isActive [Status] from RoomTable";
                }
                else
                {
                    query = "select RoomID [ID],RoomNo [Room],Capacity, isActive [Status] from RoomTable where RoomNo like '%" + searchString.Trim() + "%'";
                }

                DataTable roomList = DatabaseLayer.Retrieve(query);
                dgvRooms.DataSource = roomList;
                if (dgvRooms.Rows.Count > 0)
                {
                    dgvRooms.Columns[0].Width = 80;
                    dgvRooms.Columns[1].Width = 150;
                    dgvRooms.Columns[2].Width = 100;
                    dgvRooms.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch
            {
                MessageBox.Show("Unexpected issue encountered. Please retry!");
            }
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtProgSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtRoomSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtRoomNo.Text.Length == 0 || txtRoomNo.Text.Length > 20)
            {
                Ep.SetError(txtRoomNo, "Enter correct Room Number but must be less than 10 values!");
                txtRoomNo.Focus();
                txtRoomNo.SelectAll();
                return;
            }

            if (txtCapacity.Text.Length == 0 )
            {
                Ep.SetError(txtCapacity, "Enter correct Room Capacity !");
                txtCapacity.Focus();
                txtCapacity.SelectAll();
                return;
            }

            DataTable chkRoomNo = DatabaseLayer.Retrieve("select * from RoomTable where RoomNo = '" + txtRoomNo.Text.Trim() + "'");
            if (chkRoomNo != null)
            {
                if (chkRoomNo.Rows.Count > 0)
                {
                    Ep.SetError(txtRoomNo, "Enter already exists!");
                    txtRoomNo.Focus();
                    txtRoomNo.SelectAll();
                    return;
                }
            }

            string insertQuery = string.Format("insert into RoomTable(RoomNo,Capacity,isActive) values('{0}','{1}','{2}')",
                txtRoomNo.Text.Trim(),txtCapacity.Text.Trim(), chkRoomStatus.Checked);
            bool result = DatabaseLayer.Insert(insertQuery);
            if (result == true)
            {
                MessageBox.Show("Saved Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Room Details.");
            }
        }
        public void clearForm()
        {
            txtRoomNo.Clear();
            txtCapacity.Clear();
            chkRoomStatus.Checked = false;
        }

        public void enableComponent()
        {
            dgvRooms.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtRoomSearch.Enabled = false;
        }

        public void disableComponent()
        {
            dgvRooms.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtRoomSearch.Enabled = true;
            clearForm();
            FillGrid(string.Empty);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            disableComponent();
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            if (dgvRooms != null)
            {
                if (dgvRooms.Rows.Count > 0)
                {
                    if (dgvRooms.SelectedRows.Count == 1)
                    {
                        txtRoomNo.Text = Convert.ToString(dgvRooms.CurrentRow.Cells[1].Value);
                        txtCapacity.Text = Convert.ToString(dgvRooms.CurrentRow.Cells[2].Value);
                        chkRoomStatus.Checked = Convert.ToBoolean(dgvRooms.CurrentRow.Cells[3].Value);
                        enableComponent();
                    }
                    else
                    {
                        MessageBox.Show("Select only 1 row.");
                    }
                }
                else
                {
                    MessageBox.Show("Empty List!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Ep.Clear();
            if (txtRoomNo.Text.Length == 0 || txtRoomNo.Text.Length > 10)
            {
                Ep.SetError(txtRoomNo, "Enter correct Room Number but must be less than 10 values!");
                txtRoomNo.Focus();
                txtRoomNo.SelectAll();
                return;
            }

            if (txtCapacity.Text.Length == 0)
            {
                Ep.SetError(txtCapacity, "Enter correct Room Capacity !");
                txtCapacity.Focus();
                txtCapacity.SelectAll();
                return;
            }

            DataTable chkRoomNo = DatabaseLayer.Retrieve("select * from RoomTable where RoomNo = '" + txtRoomNo.Text.Trim() + "' and RoomID != '" + Convert.ToString(dgvRooms.CurrentRow.Cells[0].Value) + "'");
            if (chkRoomNo != null)
            {
                if (chkRoomNo.Rows.Count > 0)
                {
                    Ep.SetError(txtRoomNo, "Enter already exists!");
                    txtRoomNo.Focus();
                    txtRoomNo.SelectAll();
                    return;
                }
            }

            string updateQuery = string.Format("update RoomTable set RoomNo = '{0}',Capacity = '{1}',isActive = '{2}' where RoomID = '{3}'",
                txtRoomNo.Text.Trim(),txtCapacity.Text.Trim(), chkRoomStatus.Checked, Convert.ToString(dgvRooms.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updateQuery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully.");
                disableComponent();
            }
            else
            {
                MessageBox.Show("Please provide correct Room Details.");
            }
        }
    }
}
