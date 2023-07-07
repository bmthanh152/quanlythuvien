using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom_HungTrietThanh
{
    public class KhachHang
    {
        public string TenKH { get; set; }
        public int SLSach { get; set; }
        public bool LaSV { get; set; }
        const double Gia = 20000;
        public double TinhTien
        {
            get
            {
                if (TenKH == "")
                    return 0;
                if (LaSV == true)
                    return SLSach * Gia * 0.95;
                else
                    return SLSach * Gia;
            }
        }
       
    }
}
