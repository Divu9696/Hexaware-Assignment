using System;

namespace StudentInfoSystem.Entity;

public class Payment
{
    //Task 1 - Define Payment Class
        public int PaymentID { get; set; }
        public Student Student { get; set; }
        public decimal Amount {  get; set; }
        public DateTime PaymentDate {  get; set; }

       
}
