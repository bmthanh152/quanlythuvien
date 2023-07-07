using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom_HungTrietThanh
{
    public class ThongKeKH
    {
        List<KhachHang> DSKH = new List<KhachHang>();
        public int SLSach { get; set; }
        public void KHMua(KhachHang KH)
        {
            DSKH.Add(KH);
        }
        
        public int TongSoKH
        {  
            get
            {               
                    return DSKH.Count;                                                    
            }
        }
        public int TongSoSV
        {
            get
            {
                int SV = 0;
                foreach (KhachHang KH in DSKH)
                    if (KH.LaSV == true)
                        SV++;
                return SV;                                                          
            }
        }
        public double TongDT
        {
            get
            {
                double Tong = 0;
                foreach (KhachHang KH in DSKH)
                Tong += KH.TinhTien;
                return Tong;
                                    
            }
        }
    }
}
