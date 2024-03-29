﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace banifiu
{
    public partial class lecture : Form
    {
        connect2 con2 = new connect2();//call class connect
        MySqlCommand cmd2;
        MySqlDataReader reader2;
        MySqlDataAdapter adapter2;
        DataTable dt2;
        DataSet ds2;

        MySqlCommand cmd;
        // MySqlDataReader reader;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataSet ds;

        connect con = new connect();

        public lecture()
        {
            InitializeComponent();
        }


        public void lecture_load()
        {
            dgvLecturer.DataSource = null; 
            con.connection();
            adapter = new MySqlDataAdapter("Select lecturerID'lecturerID',lecturerName'lecturerName',faculty'faculty',department'department',center'center',building'building',level'level',rank'rank' from lecturer ", con.con);
            dt = new DataTable();
            adapter.Fill(dt);
            dgvLecturer.DataSource = dt;
            con.con.Close();

        }


       
  

        private void lecture_Load(object sender, EventArgs e)
        {
            lecture_load();
        }





        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            if (txtLecturerID.Text == "" || txtLecturerName.Text == "" || cmbFaculty.Text == "" || cmbDepartment.Text == "" || cmbCenter.Text == "" || cmbBuilding.Text == "" || cmbLevel.Text == "")
            {
                MessageBox.Show("No Data Selected", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                
                //var grpID = string.Concat(cmbAca.Text, ".", cmbGrp.Text);
                con2.datasend("insert into lecturer (`lecturerID`,`lecturerName`, `faculty`, `department`, `center`, `building`, `level`, `rank`) Value('" + txtLecturerID.Text + "','" + txtLecturerName.Text + "','" + cmbFaculty.Text + "', '" + cmbDepartment.Text + "', '" + cmbCenter.Text + "','" + cmbBuilding.Text + "','" + cmbLevel.Text + "','" + txtRank.Text + "')");
                txtLecturerID.Text = "";
                txtLecturerName.Text = "";
                cmbFaculty.SelectedItem = null;
                cmbDepartment.SelectedItem = null;
                cmbCenter.SelectedItem = null;
                cmbBuilding.SelectedItem = null;
                cmbLevel.SelectedItem = null;
                txtRank.Text = "";

                MessageBox.Show("Successfully Data Added", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lecture_load();
                btnUpdate.Enabled = false;
    
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            con2.datadelete("delete from  lecturer where lecturerID= '" + txtLecturerID.Text + "'");
            txtLecturerID.Text = "";
            txtLecturerName.Text = "";
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            txtRank.Text = "";
            MessageBox.Show("Successfully Deleted", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lecture_load();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            con.dataupdate("update lecturer set lecturerID= '" + txtLecturerID.Text + "',lecturerName='" + txtLecturerName.Text + "',faculty='" + cmbFaculty.Text + "',department='" + cmbDepartment.Text + "',center ='" + cmbCenter.Text + "',building='" + cmbBuilding.Text + "',level='" + cmbLevel.Text + "' where lecturerID='" + txtLecturerID.Text + "'");
            txtLecturerID.Text = "";
            txtLecturerName.Text = "";
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            txtRank.Text = "";
            MessageBox.Show("Successfully Updated", "Lecturer Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lecture_load();
        }

        private void dgvLecturer_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLecturer.Rows[e.RowIndex];
                txtLecturerID.Text = row.Cells[0].Value.ToString();
                txtLecturerName.Text = row.Cells[1].Value.ToString();
                cmbFaculty.Text = row.Cells[2].Value.ToString();
                cmbDepartment.Text = row.Cells[3].Value.ToString();
                cmbCenter.Text = row.Cells[4].Value.ToString();
                cmbBuilding.Text = row.Cells[5].Value.ToString();
                cmbLevel.Text = row.Cells[6].Value.ToString();
                txtRank.Text = row.Cells[7].Value.ToString();
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            con2.connection();
            cmd2 = new MySqlCommand("Select * from lecturer where lecturerID= '" + txtLecturerID.Text + "'", con2.con2);
            reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                txtLecturerID.Text = reader2.GetString("lecturerID");
                txtLecturerName.Text = reader2.GetString("lecturerName");
                cmbFaculty.Text = reader2.GetString("faculty");
                cmbDepartment.Text = reader2.GetString("department");
                cmbCenter.Text = reader2.GetString("center");
                cmbBuilding.Text = reader2.GetString("building");
                cmbLevel.Text = reader2.GetString("level");
                txtRank.Text = reader2.GetString("rank");
            }
            else
            {
                txtLecturerID.Text = "";
                txtLecturerName.Text = "";
                cmbFaculty.SelectedItem = null;
                cmbDepartment.SelectedItem = null;
                cmbCenter.SelectedItem = null;
                cmbBuilding.SelectedItem = null;
                cmbLevel.SelectedItem = null;
                txtRank.Text = "";
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtLecturerID.Text = "";
            txtLecturerName.Text = "";
            cmbFaculty.SelectedItem = null;
            cmbDepartment.SelectedItem = null;
            cmbCenter.SelectedItem = null;
            cmbBuilding.SelectedItem = null;
            cmbLevel.SelectedItem = null;
            txtRank.Text = "";

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            txtRank.Text = cmbLevel.Text + "." + txtLecturerID.Text;
        }
    }
}
