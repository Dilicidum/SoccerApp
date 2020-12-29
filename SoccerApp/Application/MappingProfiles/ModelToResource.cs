using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using BLL.Models.Resources;
using Application.Models;

namespace Application.MappingProfiles
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<UserLoginModel, User>().ReverseMap();
            CreateMap<UserRegistrationModel, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PlayerDTO, PatchPlayerDTO>().ReverseMap();

            CreateMap<Player, PlayerDTO>()
                .ForMember(x => x.Position, options => options.MapFrom(CreateEnumShortNameExpression<Player, Position>(x => x.Position)))
                .ForMember(x => x.Country, options => options.MapFrom(x => x.Country))
                .ForMember(x => x.Team, options => options.MapFrom(x => x.Team))
                .ReverseMap();
            CreateMap<Team, TeamDTO>()
                .ForMember(x => x.Players, src => src.MapFrom(x => x.Players))
                .ForMember(x => x.Home_Games, src => src.MapFrom(x => x.Home_Games))
                .ForMember(x => x.Guest_Games, src => src.MapFrom(x => x.Guest_Games))
                .ForMember(x => x.Current_Leagues, src => src.MapFrom(x => x.Current_Leagues))
                .ReverseMap();
            CreateMap<League,LeagueDTO>()
                .ForMember(x => x.Countries, src => src.MapFrom(x => x.Countries))
                .ForMember(x => x.Games, src => src.MapFrom(x => x.Games))
                .ForMember(x => x.Teams, src => src.MapFrom(x => x.Teams))
                .ForMember(x => x.StatusOfLeague, src => src.MapFrom(CreateEnumShortNameExpression<League,StatusOfLeague>(x=>x.StatusOfLeague)))
                .ReverseMap();
            CreateMap<Stadium, StadiumDTO>()
                .ForMember(x => x.Games, x => x.MapFrom(c => c.Games)).ReverseMap();
            CreateMap<CCountry, CountryDTO>()
                .ForMember(x => x.Name, options => options.MapFrom(CreateEnumShortNameExpression<CCountry, Country>(x => x.Country)))
                .ReverseMap();
            CreateMap<Team_League, Team_LeagueDTO>()
                .ForMember(x => x.League, options => options.MapFrom(x => x.League))
                .ForMember(x => x.Team, options => options.MapFrom(x => x.Team)).ReverseMap();
            CreateMap<Game, GameDTO>()
                .ForMember(x => x.GameResult, options => options.MapFrom(CreateEnumShortNameExpression<Game, GameResult>(x => x.GameResult)))
                .ForMember(x => x.Status, options => options.MapFrom(CreateEnumShortNameExpression<Game, GameStatus>(x => x.Status)))
                .ForMember(x => x.StartTime, options => options.MapFrom(src => src.TimeStart))
                .ReverseMap();


            CreateMap<Game, GameUploadModel>()
                .ForMember(x => x.House_TeamId, options => options.MapFrom(src => src.House_Team_Id))
                .ForMember(x => x.Guest_TeamId, options => options.MapFrom(src => src.Guest_Team_Id))
                .ForMember(x => x.stadiumId, options => options.MapFrom(src => src.Stadium_Id))
                .ForMember(x => x.League_Id, options => options.MapFrom(src => src.LeagueId))
                .ForMember(x => x.GameResult, options => options.MapFrom(CreateEnumShortNameExpression<Game, GameResult>(x => x.GameResult)))
                .ForMember(x => x.Status, options => options.MapFrom(CreateEnumShortNameExpression<Game, GameStatus>(x => x.Status)))
                .ForMember(x => x.StartTime, options => options.MapFrom(src => src.TimeStart))
                .ReverseMap();
                

            CreateMap<Player,PlayerUploadModel>()
                .ForMember(x => x.Position, options => options.MapFrom(CreateEnumShortNameExpression<Player, Position>(x => x.Position)))
                .ForMember(x => x.Country, options => options.MapFrom(x => x.Country))
                .ReverseMap(); 
        }

        

        public static Expression<Func<TEntity, string>> CreateEnumShortNameExpression<TEntity, TEnum>
            (Expression<Func<TEntity, TEnum>> propertyExpression)
        where TEntity : class
        where TEnum : struct
        {
            var enumValues = Enum.GetValues(typeof(TEnum)).Cast<Enum>();
            Expression resultExpression = Expression.Constant(string.Empty);
            foreach (var enumValue in enumValues)
            {
                resultExpression = Expression.Condition(
                    Expression.Equal(propertyExpression.Body, Expression.Constant(enumValue)),
                    Expression.Constant(EnumHelper.GetShortName(enumValue)),
                    resultExpression);
            }

            return Expression.Lambda<Func<TEntity, string>>(resultExpression, propertyExpression.Parameters);
        }
    }
    public static class EnumHelper
    {
        public static string GetShortName(this Enum enumeration)
        {
            return (enumeration
                .GetType()
                .GetMember(enumeration.ToString())?
                .FirstOrDefault()?
                .GetCustomAttributes(typeof(DisplayAttribute), false)?
                .FirstOrDefault() as DisplayAttribute)?
                .ShortName ?? enumeration.ToString();
        }

        
    }



}
