namespace BrightFocus.Core.Models.DeliveryWarehouses.Models
{
    public class DeliveryWarehouseDto : IMapFrom<DeliveryWarehouseEntity>
    {
        public string FromWarehouse { get; set; } = string.Empty;
        public string ToWarehouse { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Employee { get; set; } = string.Empty;
        public DeliveryType DeliveryType { get; set; }
        public Guid TaskId { get; set; }

        public static List<(string FromWarehouse, string ToWarehouse)> GetWarehousePairs(IEnumerable<TaskDetailDto> taskDetails)
        {
            if (taskDetails == null || !taskDetails.Any())
            {
                return [];
            }

            List<string> warehouses = taskDetails
                .Where(detail => !string.IsNullOrWhiteSpace(detail.Warehouse))
                .Select(detail => detail.Warehouse)
                .Distinct()
                .ToList();

            List<(string FromWarehouse, string ToWarehouse)> warehousePairs = [];

            for (int i = 0; i < warehouses.Count; i++)
            {
                for (int j = i + 1; j < warehouses.Count; j++)
                {
                    warehousePairs.Add((warehouses[i], warehouses[j]));
                }
            }

            return warehousePairs;
        }
    }
}
