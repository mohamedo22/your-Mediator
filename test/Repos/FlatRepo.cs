using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using test.Configuration;
using test.Dto;
using test.Interface;
using test.Model;

namespace test.Repos
{
    public class FlatRepo : IFlatRepo
    {
        private readonly AppDbContext _context;

        public FlatRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool EditFlat(PostFlatDto postFlatDto, int id)
        {
            var flat = _context.Flat.FirstOrDefault(x => x.FlatCodeId == id);
            if (flat != null)
            {
                flat.FlatBathrooms = postFlatDto.FlatBathrooms;
                flat.FlatBedrooms = postFlatDto.FlatBedrooms;
                flat.FlatGovernorate = postFlatDto.FlatGovernorate;
                flat.FlatPrice = postFlatDto.FlatPrice;
                flat.FloorNumber = postFlatDto.FloorNumber;
                flat.FlatDetails = postFlatDto.FlatDetails;
                flat.FlatCity = postFlatDto.FlatCity;
                _context.Flat.Update(flat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<GetFlatDto> GetFlat()
        {
            if (_context.Flat != null)
            {
                return _context.Flat.Select(x => new GetFlatDto
                {
                    FlatAddress = x.FlatAddress,
                    FlatCity = x.FlatCity,
                    FlatBathrooms = x.FlatBathrooms,
                    FlatBedrooms = x.FlatBedrooms,
                    FlatDetails = x.FlatDetails,
                    FlatGovernorate = x.FlatGovernorate,
                    FlatPrice = x.FlatPrice,
                    FloorNumber = x.FloorNumber,

                }).ToList();
            }
            else
            {
                return null;
            }
        }

        public bool PostFlat(PostFlatDto postFlatDto)
        {
                bool status = false;
                if (!string.IsNullOrWhiteSpace(postFlatDto.FlatAddress) &&
                    !string.IsNullOrWhiteSpace(postFlatDto.FlatDetails) &&
                    !string.IsNullOrWhiteSpace(postFlatDto.FlatCity))
                {
                    var flat = new Flat
                    {
                        FlatAddress = postFlatDto.FlatAddress,
                        FlatCity = postFlatDto.FlatCity,
                        FlatDetails = postFlatDto.FlatDetails,
                        FlatPrice = postFlatDto.FlatPrice,
                        FlatBathrooms = postFlatDto.FlatBathrooms,
                        FloorNumber = postFlatDto.FloorNumber,
                        FlatBedrooms = postFlatDto.FlatBedrooms,
                        FlatGovernorate = postFlatDto.FlatGovernorate
                    };
                    _context.Flat.Add(flat);
                    _context.SaveChanges();
                    status = true;
                    return status;
                }
                else
                {
                    return status;
                }
        }

        public bool RemoveFlat(int FlatId)
        {
                var flat = _context.Flat.FirstOrDefault(x => x.FlatCodeId == FlatId);
                if (flat != null)
                {
                    _context.Flat.Remove(flat);
                    _context.SaveChanges();
                return true;
                }
                else { return false; }
        }
    }
}
