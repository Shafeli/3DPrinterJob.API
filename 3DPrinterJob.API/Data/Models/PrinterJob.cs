using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3DPrinterJob.API.Models
{

    public class PrinterJob
    {
        public int Id { get; set; }                                 // id of the print job
        public string Name { get; set; }                            // name of the print job


        public string? DownloadLink { get; set; }                    // link to download the 3D model file
        public string? Notes { get; set; }                           // additional notes about the print job


        public int StatusId { get; set; }                           // foreign key to Status
        public Status Status { get; set; }                          // navigation property to Status


        public int RequesterId { get; set; }                        // foreign key to Requester
        public Requester Requester { get; set; }                    // navigation property to Requester

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;   // date the print job was created
    }
}
