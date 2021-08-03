using CrossStitchery.Data;
using CrossStitchery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Services
{
    public class FlossService
    {
        private readonly Guid _userId;

        public FlossService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFloss(FlossCreate model)
        {
            var entity =
                new Floss()
                {
                    OwnerId = _userId,
                    ColorNumber = model.ColorNumber,
                    ColorName = model.ColorName,
                    BobbinAmount = model.BobbinAmount
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Floss.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FlossListItem> GetFloss()
        {
            using(var ctx= new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Floss
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new FlossListItem
                        {
                            FlossId = e.FlossId,
                            ColorNumber = e.ColorNumber,
                            ColorName = e.ColorName
                        });
                return query.ToArray();
            }
        }

        public FlossDetail GetFlossById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Floss
                    .Single(e => e.FlossId == id && e.OwnerId == _userId);
                return
                    new FlossDetail
                    {
                        FlossId = entity.FlossId,
                        ColorNumber = entity.ColorNumber,
                        ColorName = entity.ColorName,
                        BobbinAmount = entity.BobbinAmount,
                        //InStock = entity.InStock
                    };
            }
        }

        public bool UpdateFloss(FlossEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Floss
                    .Single(e => e.FlossId == model.FlossId && e.OwnerId == _userId);
                entity.ColorNumber = model.ColorNumber;
                entity.ColorName = model.ColorName;
                entity.BobbinAmount = model.BobbinAmount;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFloss(int flossId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Floss
                    .Single(e => e.FlossId == flossId && e.OwnerId == _userId);
                ctx.Floss.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
