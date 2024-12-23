using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_Buoi8
{
    public partial class Form1 : Form
    {
        private Model1 context;
        public class Model2 : DbContext
        {
            public Model2() : base("name=Model2")
            {
            }

            public virtual DbSet<SinhVien> SinhViens { get; set; }
            // Các DbSet khác
        }
        public Form1()
        {
            InitializeComponent();
            context = new Model1();
        }
        private void LoadData()
        {
            var sinhViens = context.SinhViens.ToList();  // Lấy tất cả sinh viên từ cơ sở dữ liệu
            dvgSinhVien.DataSource = sinhViens;  // Hiển thị dữ liệu lên DataGridView

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var sinhVien = new SinhVien
                {
                    MaSV = txtMa.Text,
                    TenSV = txtTen.Text,
                    Khoa = cbmKhoa.Text,
                    DiemTB = Convert.ToDecimal(txtDiem.Text)
                };

                context.SinhViens.Add(sinhVien);  // Thêm sinh viên vào DbSet
                context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                MessageBox.Show("Thêm sinh viên thành công!");
                LoadData();  // Tải lại dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var maSV = txtMa.Text;
                var sinhVien = context.SinhViens.SingleOrDefault(sv => sv.MaSV == maSV);

                if (sinhVien != null)
                {
                    sinhVien.TenSV = txtTen.Text;
                    sinhVien.Khoa = cbmKhoa.Text;
                    sinhVien.DiemTB = Convert.ToDecimal(txtDiem.Text);

                    context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                    MessageBox.Show("Sửa thông tin sinh viên thành công!");
                    LoadData();  // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã " + maSV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var maSV = txtMa.Text;
                var sinhVien = context.SinhViens.SingleOrDefault(sv => sv.MaSV == maSV);

                if (sinhVien != null)
                {
                    context.SinhViens.Remove(sinhVien);  // Xoá sinh viên
                    context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                    MessageBox.Show("Xoá sinh viên thành công!");
                    LoadData();  // Tải lại dữ liệu
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với mã " + maSV);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }   
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbmKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dvgSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dvgSinhVien.Rows[e.RowIndex];
                txtMa.Text = row.Cells["MaSV"].Value.ToString();
                txtTen.Text = row.Cells["TenSV"].Value.ToString();
                cbmKhoa.Text = row.Cells["Khoa"].Value.ToString();
                txtDiem.Text = row.Cells["DiemTB"].Value.ToString();
            }
        }
    }
}
