using AssiT.Core.Entities;

namespace AssiT.Application.Models.AssetModels;

public class AssetsDetailsViewModel
{
    public AssetsDetailsViewModel(int id, int categoryId, string name, string serialNumber, DateTime acquisitionDate, decimal acquisitionValue)
    {
        Id = id;
        CategoryId = categoryId;
        Name = name;
        SerialNumber = serialNumber;
        AcquisitionDate = acquisitionDate;
        AcquisitionValue = acquisitionValue;
    }

    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public DateTime AcquisitionDate { get; set; }
    public decimal AcquisitionValue { get; set; }
    /*public static AssetsViewModel FromEntity(Asset Asset) =>
        new AssetsViewModel(
            id: Asset.Id,
            categoryId:Asset.CategoryId,
            Asset.Name,
            serialNumber: Asset.SerialNumber,
            acquisitionDate: Asset.AcquisitionDate,
            acquisitionValue: Asset.AcquisitionValue
         );*/
}
