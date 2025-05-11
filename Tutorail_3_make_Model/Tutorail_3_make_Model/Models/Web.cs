using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tutorail_3_make_Model.Models
{
    public class Web
    {   
        [Key]// สร้างรหัส auto และไม่ซ้ำกัน

        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ชื่อเว็ปไซต์")]// [Required] ห้ามเป็นค่าว่าง
        [DisplayName("กรอกข้อมูล ชื่อ Website")]
        public string nameLink { get; set; }

        [Required(ErrorMessage = "กรุณากรอกลิงค์เว็ปไซต์")]
        [DisplayName("กรอกข้อมูล ลิงค์ Website")] // แสดงข้อความไปที่หน้า View  // [Rage 0,100] ตัวบังคับจำนวนค่าที่ใส่เข้ามา
        public string link { get; set; }
        [DisplayName("ไม่สามารถอัพเดตได้")] // แสดงข้อความไปที่หน้า View  // [Rage 0,100] ตัวบังคับจำนวนค่าที่ใส่เข้ามา
        public bool mark { get; set; }

        [DisplayName("เวลาที่สร้าง")]
        public DateTime create_at { get; set; }

        [DisplayName("เวลาอัพเดต")]
        public DateTime update_at { get; set; }

    }
}
