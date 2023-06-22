using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pragmatic.Common.Entities
{
    internal class Reminder
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public String Description { get; set; }

        [Required]
        public Int32? TaskStatusId { get; set; }
        [ForeignKey("Id")]
        public virtual TaskStatus TaskStatus { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        [Required]
        [MaxLength(50)]
        public String CreatedBy { get; set; }

        [Required]
        public DateTime? Updated { get; set; }

        [Required]
        [MaxLength(50)]
        public String UpdatedBy { get; set; }
    }
}
