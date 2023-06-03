using AutoMapper;
using Medium.Application.Repositories.Abstractions;
using Medium.Application.UnitOfWorks;
using Medium.Domain.Entities;
using Medium.Infrasturucture.Dtos.Entities.Get;
using Medium.Infrasturucture.Dtos.Entities.Post;
using Medium.Infrasturucture.Services.Entities.Abstractions;
using Result;

namespace Medium.Infrasturucture.Services.Entities.Implementations
{
    public class TagService : ITagService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IGenericRepository<Tag> _genericRepository;
        readonly IMapper _mapper;
        public TagService(IUnitOfWork unitOfWork, IGenericRepository<Tag> genericRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetTagDto>> AddTag(AddTagDto addTagDto)
        {
            var entity = _mapper.Map<Tag>(addTagDto);
            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return Response<GetTagDto>.Success(_mapper.Map<GetTagDto>(entity));
        }

        public async Task<Response<NoDataDto>> DeleteTag(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity != null)
            {
                _genericRepository.Remove(entity);
                _unitOfWork.Commit();
                return Response<NoDataDto>.Success("remove successfull");
            }
            return Response<NoDataDto>.Fail("no data found");
        }

        public async Task<Response<GetTagDto>> GetTag(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity != null)
            {
                return Response<GetTagDto>.Success(_mapper.Map<GetTagDto>(entity));
            }
            return Response<GetTagDto>.Fail("no data found");
        }

        public async Task<Response<IEnumerable<GetTagDto>>> GetTags()
        {
            var entities = await _genericRepository.GetAllAsync();
            if (entities != null)
            {
                return Response<GetTagDto>.Success(_mapper.Map<IEnumerable<GetTagDto>>(entities));
            }
            return Response<IEnumerable<GetTagDto>>.Fail("no data found");
        }

        public async Task<Response<GetTagDto>> UpdateTag(AddTagDto addTagDto, int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            if (entity != null)
            {
                if (!string.IsNullOrEmpty(addTagDto.Title))
                {
                    entity.Title = addTagDto.Title;
                    entity.UpdatedDate = DateTime.Now;
                }
                _genericRepository.Update(entity);
                _unitOfWork.Commit();

                return Response<GetTagDto>.Success(_mapper.Map<GetTagDto>(entity));
            }
            return Response<GetTagDto>.Fail("No data found");
        }
    }
}
