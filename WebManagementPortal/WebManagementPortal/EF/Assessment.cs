//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebManagementPortal.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assessment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assessment()
        {
            this.Choices = new HashSet<Choice>();
            this.RecLog = new RecordLog();
        }
    
        public int Id { get; set; }
        public int Order { get; set; }
        public string ContentType { get; set; }
        public string Question { get; set; }
        public string StatementBefore { get; set; }
        public string StatementAfter { get; set; }
        public int AssessmentItemId { get; set; }
    
        public RecordLog RecLog { get; set; }
    
        public virtual AssessmentItem AssessmentItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Choice> Choices { get; set; }
    }
}
