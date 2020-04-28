using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Model.Entity
{
    public class BaseEntity : IDisposable
    {
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);

        private bool _disposed;

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Display(Name = "فعال")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "تاریخ آخرین تغییر")]
        public DateTime LastModifiedDate { get; set; }

        [Display(Name = "حذف شده")]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [Display(Name = "تاریخ حذف")] public DateTime? DeletionDate { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseEntity()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _handle.Dispose();
            _disposed = true;
        }
    }
}