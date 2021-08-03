using CrossStitchery.Data;
using CrossStitchery.Models.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossStitchery.Services
{
    public class PatternService
    {
        private readonly Guid _userId;

        public PatternService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePattern(PatternCreate model)
        {
            var entity =
                new Pattern()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    NumberOfColors = model.NumberOfColors,
                    Level = model.Level,
                    Height = model.Height,
                    Width = model.Width,
                    Backstitching = model.Backstitching
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pattern.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PatternListItem> GetPattern()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Pattern
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new PatternListItem
                        {
                            PatternId = e.PatternId,
                            Name = e.Name,
                            Level = e.Level,
                            Height = e.Height,
                            Width = e.Width
                        });
                return query.ToArray();
            }
        }

        public PatternDetail GetPatternById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Pattern
                    .Single(e => e.PatternId == id && e.OwnerId == _userId);
                return
                    new PatternDetail
                    {
                        PatternId = entity.PatternId,
                        Name = entity.Name,
                        NumberOfColors = entity.NumberOfColors,
                        Level= entity.Level,
                        Height=entity.Height,
                        Width=entity.Width,
                        Backstitching=entity.Backstitching
                    };
            }
        }

        public bool UpdatePattern(PatternEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Pattern
                    .Single(e => e.PatternId == model.PatternId && e.OwnerId == _userId);
                entity.Name = model.Name;
                entity.NumberOfColors = model.NumberOfColors;
                entity.Level = model.Level;
                entity.Height = model.Height;
                entity.Width = model.Width;
                entity.Backstitching = model.Backstitching;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePattern(int patternId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Pattern
                    .Single(e => e.PatternId == patternId && e.OwnerId == _userId);
                ctx.Pattern.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
