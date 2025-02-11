using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
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
            var flat = _context.Flat.Include(f => f.FlatImages).FirstOrDefault(x => x.FlatCodeId == id);
            if (flat != null)
            {
                flat.FlatBathrooms = postFlatDto.FlatBathrooms;
                flat.FlatBedrooms = postFlatDto.FlatBedrooms;
                flat.FlatGovernorate = postFlatDto.FlatGovernorate;
                flat.FlatPrice = postFlatDto.FlatPrice;
                flat.FloorNumber = postFlatDto.FloorNumber;
                flat.FlatDetails = postFlatDto.FlatDetails;
                flat.FlatCity = postFlatDto.FlatCity;
                if (postFlatDto.FlatImages != null && postFlatDto.FlatImages.Count > 0)
                {
                    flat.FlatImages = new List<FlatImages>(); 
                    foreach (var imageFile in postFlatDto.FlatImages)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);
                            flat.FlatImages.Add(new FlatImages
                            {
                                Flatimage = memoryStream.ToArray(),
                                FlatCodeId = flat.FlatCodeId
                            });
                        }
                    }
                }
                if (postFlatDto.FlatDocs != null && postFlatDto.FlatDocs.Count > 0)
                {
                    flat.FlatDocs = new List<FlatImagesDocs>();
                    foreach (var imageFile in postFlatDto.FlatDocs)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);
                            flat.FlatDocs.Add(new FlatImagesDocs
                            {
                                Flatimage = memoryStream.ToArray(),
                                FlatCodeId = flat.FlatCodeId
                            });
                        }
                    }
                }
                _context.Flat.Update(flat);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditFlat(string status, int id)
        {
            var flat = _context.Flat.Include(f => f.FlatImages).Include(f => f.FlatDocs).FirstOrDefault(x => x.FlatCodeId == id);
            if (flat != null)
            {
                flat.Status = status;

                _context.Flat.Update(flat);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
         
        }
        public List<GetFlatDto> GetFlat()
        {
            if (_context.Flat != null)
            {
                return _context.Flat.Include(f => f.FlatImages).Select(x => new GetFlatDto
                {
                    FlatAddress = x.FlatAddress,
                    FlatCity = x.FlatCity,
                    FlatBathrooms = x.FlatBathrooms,
                    FlatBedrooms = x.FlatBedrooms,
                    FlatDetails = x.FlatDetails,
                    FlatGovernorate = x.FlatGovernorate,
                    FlatCode = x.FlatCodeId,
                    FlatPrice = x.FlatPrice,
                    FloorNumber = x.FloorNumber,
                    FlatStatus = x.Status,
                    FlatImages = x.FlatImages.Select(img => new FlatImagesGetDto
                    {
                        ImageBase64 = Convert.ToBase64String(img.Flatimage)
                    }).ToList(),
                    FlatDocs = x.FlatDocs.Select(img => new FlatImagesGetDto
                    {
                        ImageBase64 = Convert.ToBase64String(img.Flatimage)
                    }).ToList(),

                }).ToList();
            }
            else
            {
                return null;
            }
        }

        public bool PostFlat(PostFlatDto postFlatDto)
        {
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
                    FlatGovernorate = postFlatDto.FlatGovernorate,
                    FlatImages = new List<FlatImages>(),
                    FlatDocs = new List<FlatImagesDocs>(),
                };

                if (postFlatDto.FlatImages != null && postFlatDto.FlatImages.Count > 0)
                {
                    foreach (var imageFile in postFlatDto.FlatImages)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);
                            flat.FlatImages.Add(new FlatImages
                            {
                                Flatimage = memoryStream.ToArray()
                            });
                        }
                    }
                }
                if (postFlatDto.FlatDocs != null && postFlatDto.FlatDocs.Count > 0)
                {
                    foreach (var imageFile in postFlatDto.FlatDocs)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imageFile.CopyTo(memoryStream);
                            flat.FlatDocs.Add(new FlatImagesDocs
                            {
                                Flatimage = memoryStream.ToArray()
                            });
                        }
                    }
                }

                _context.Flat.Add(flat);
                _context.SaveChanges();
                return true;
            }
            return false;
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
