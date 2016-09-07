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
    
    public partial class AssessmentItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentItem()
        {
            this.Assessments = new HashSet<Assessment>();
            this.RecLog = new RecordLog();
        }
    
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public string IconURL { get; set; }
        public bool IsPreviewable { get; set; }
        public Nullable<int> PreLessonId { get; set; }
        public Nullable<int> PostLessonId { get; set; }
    
        public RecordLog RecLog { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual Lesson PreLesson { get; set; }
        public virtual Lesson PostLesson { get; set; }
    }
}
