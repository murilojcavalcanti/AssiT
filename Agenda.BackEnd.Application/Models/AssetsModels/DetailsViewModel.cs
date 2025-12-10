using AssiT.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace AssiT.Application.Models.AssetModels;

public class AssetsViewModel
{
    public AssetsViewModel(int id, int categoryId, string number, string serialNumber, DateTime acquisitionDate, DateTime acquisitionValue)
    {
        Id = id;
        CategoryId = categoryId;
        Number = number;
        SerialNumber = serialNumber;
        AcquisitionDate = acquisitionDate;
        AcquisitionValue = acquisitionValue;
    }

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Number { get; set; }
    public string SerialNumber { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public DateTime AcquisitionValue { get; set; }
    public static AssetsViewModel FromEntity(Asset Asset) =>
        new AssetsViewModel(
            id: Asset.Id,
            categoryId:Asset.CategoryId,
            number: Asset.Number,
            serialNumber: Asset.SerialNumber,
            acquisitionDate: Asset.AcquisitionDate,
            acquisitionValue: Asset.AcquisitionValue
         );
}
