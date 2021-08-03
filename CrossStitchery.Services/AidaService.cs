using CrossStitchery.Data;
using CrossStitchery.Models.Aida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Services
{
    public class AidaService
    {
        private readonly Guid _userId;

        public AidaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAida(AidaCreate model)
        {
            var entity =
                new Aida()
                {
                    OwnerId = _userId,
                    Count = model.Count,
                    Color = model.Color,
                    Height = model.Height,
                    Width = model.Width
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Aida.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AidaListItem> GetAida()
        {
            using(var ctx= new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Aida
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new AidaListItem
                        {
                            AidaId = e.AidaId,
                            Count = e.Count,
                            Color = e.Color,
                            Height = e.Height,
                            Width = e.Width
                        });
                return query.ToArray();
            }
        }

        public AidaDetail GetAidaById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aida
                    .Single(e => e.AidaId == id && e.OwnerId == _userId);
                return
                    new AidaDetail
                    {
                        AidaId = entity.AidaId,
                        Count = entity.Count,
                        Color = entity.Color,
                        Height = entity.Height,
                        Width = entity.Width
                    };
            }
        }

        public bool UpdateAida(AidaEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aida
                    .Single(e => e.AidaId == model.AidaId && e.OwnerId == _userId);
                entity.Count = model.Count;
                entity.Color = model.Color;
                entity.Height = model.Height;
                entity.Width = model.Width;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAida(int aidaId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Aida
                    .Single(e => e.AidaId == aidaId && e.OwnerId == _userId);
            ctx.Aida.Remove(entity);
            return ctx.SaveChanges() == 1;
            }
        }
    }
}
