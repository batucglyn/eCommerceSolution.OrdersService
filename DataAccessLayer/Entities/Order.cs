using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.OrdersMicroervice.DataAccessLayer.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid _id { get; set; }

   
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid OrderID { get; set; }


    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid UserID { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public DateTime OrderDate { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public decimal TotalBill { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();





}

