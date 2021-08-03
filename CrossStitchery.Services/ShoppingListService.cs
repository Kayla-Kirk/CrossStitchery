using CrossStitchery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Services
{
    public class ShoppingListService
    {
        //private readonly Guid _userId;

            //public ShoppingListService(Guid userId)
            //{
            //    _userId = userId;
            //}

            //public bool CreateShoppingList(ShoppingListCreate model)
            //{
            //    var entity =
            //        new ShoppingList()
            //        {
            //            //OwnerId = _userId,
            //            //Count = model.Count,
            //            //Color = model.Color,
            //            //Height = model.Height,
            //            //Width = model.Width
            //        };
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        ctx.ShoppingList.Add(entity);
            //        return ctx.SaveChanges() == 1;
            //    }
            //}

            //public IEnumerable<ShoppingListItem> GetAida()
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var query =
            //            ctx
            //            .ShoppingList
            //            .Where(e => e.OwnerId == _userId)
            //            .Select(
            //                e =>
            //                new ShoppingListItem
            //                {
            //                    //AidaId = e.AidaId,
            //                    //Count = e.Count,
            //                    //Color = e.Color,
            //                    //Height = e.Height,
            //                    //Width = e.Width
            //                });
            //        return query.ToArray();
            //    }
            //}

            //public ShoppingListDetail GetShoppingListById(int id)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var entity =
            //            ctx
            //            .ShoppingList
            //            .Single(e => e.AidaId == id && e.OwnerId == _userId);
            //        return
            //            new ShoppingListDetail
            //            {
            //                //AidaId = entity.AidaId,
            //                //Count = entity.Count,
            //                //Color = entity.Color,
            //                //Height = entity.Height,
            //                //Width = entity.Width
            //            };
            //    }
            //}

            //public bool UpdateShoppingList(ShoppingListEdit model)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var entity =
            //            ctx
            //            .ShoppingList
            //            .Single(e => e.ShoppingListId == model.ShoppingListId && e.OwnerId == _userId);
            //        //entity.Count = model.Count;
            //        //entity.Color = model.Color;
            //        //entity.Height = model.Height;
            //        //entity.Width = model.Width;
            //        return ctx.SaveChanges() == 1;
            //    }
            //}

            //public bool DeleteShoppingList(int shoppingListId)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var entity =
            //            ctx
            //            .ShoppingList
            //            .Single(e => e.ShoppingListId == shoppingListId && e.OwnerId == _userId);
            //        ctx.ShoppingList.Remove(entity);
            //        return ctx.SaveChanges() == 1;
            //    }
            //}
        }
    }
