using System;
using System.Collections.Generic;
using System.Linq;
using TeYou.UpdateSystem.DAL;
using TeYou.UpdateSystem.IService.TYSystem;
using TeYou.UpdateSystem.Model.TYSystem;
using TeYou.UpdateSystem.Model.Util;

namespace TeYou.UpdateSystem.Service.TYSystem
{
    public class RoleService : IRoleService
    {
        private readonly MainDataContext _context = new MainDataContext();

        /// <summary>
        /// 根据id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoleModel GetRoleInfoById(long id)
        {
            try
            {
                var model = new RoleModel();
                var entity = _context.Roles.SingleOrDefault(p => p.RlId == id);
                if (entity != null)
                {
                    model.RlId = entity.RlId;
                    model.MerId = entity.MerId;
                    model.Name = entity.Name;
                    model.Remark = entity.Remark;
                    model.ModifiedOn = entity.ModifiedOn;
                    model.ModifiedBy = entity.ModifiedBy;
                }
                return model;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-GetRoleInfoById", e);
            }
            return null;
        }

        /// <summary>
        /// 添加角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(RoleModel model)
        {
            try
            {
                Role entity = new Role
                {
                    MerId = model.MerId,
                    Name = model.Name,
                    Remark = model.Remark,
                    CreatedOn = DateTime.Now,
                    CreatedBy = model.CreatedBy
                };
                _context.Roles.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-Add", e);
            }
            return false;
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(RoleModel model)
        {
            try
            {
                var entity = _context.Roles.SingleOrDefault(p => p.RlId == model.RlId);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Remark = model.Remark;
                    entity.ModifiedOn = DateTime.Now;
                    entity.ModifiedBy = model.ModifiedBy;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-Update", e);
            }
            return false;
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            try
            {
                var entity = _context.Roles.SingleOrDefault(p => p.RlId == id);
                _context.Roles.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-Delete", e);
            }
            return false;
        }

        /// <summary>
        /// 获取角色列表数据
        /// </summary>
        /// <returns></returns>
        public List<RoleModel> GetRoleModels(RoleModel searchModel, out int totalCount)
        {
            totalCount = 0;
            try
            {
                var list = _context.Roles.Select(p => new RoleModel()
                {
                    RlId = p.RlId,
                    MerId = p.MerId,
                    Name = p.Name,
                    Remark = p.Remark,
                    CreatedOn = p.CreatedOn,
                    CreatedBy = p.CreatedBy,
                    ModifiedOn = p.ModifiedOn,
                    ModifiedBy = p.ModifiedBy
                });
                if (searchModel.MerId.GetValueOrDefault() > 0)
                {
                    list = list.Where(x => x.MerId == searchModel.MerId);
                }
                if (!string.IsNullOrEmpty(searchModel.search_name))
                {
                    list = searchModel.is_validate ? list.Where(x => x.Name == searchModel.search_name) : list.Where(x => x.Name.Contains(searchModel.search_name));
                }
                totalCount = list.Count();
                return list.OrderByDescending(o => o.CreatedOn).Skip(searchModel.pageSize * (searchModel.page - 1)).Take(searchModel.pageSize).ToList();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-GetRoleModels", e);
            }
            return null;
        }

        /// <summary>
        /// 分配角色
        /// </summary>
        /// <param name="uinr"></param>
        /// <returns></returns>
        public bool AllotRole(List<UserInRoleModel> uinr)
        {
            try
            {
                if (uinr != null)
                {
                    foreach (var item in uinr)
                    {
                        UserInRole entity = new UserInRole
                        {
                            UsId = item.UsId,
                            RlId = item.RlId
                        };
                        _context.UserInRoles.Add(entity);
                        _context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-AllotRole", e);
            }
            return false;
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<UserInRoleModel> GetUserRoles(long uid)
        {
            try
            {
                var list = _context.UserInRoles.Where(r => r.UsId == uid).Select(p =>
                new UserInRoleModel {
                    RlId = p.RlId.Value,
                    UsId = p.UsId.Value,
                    UrId = p.UrId
                });
                return list.ToList();
            }
            catch(Exception e) 
            {
                LogHelper.WriteLog("RoleService-GetUserRoles", e);
            }
            return null;
        }

        /// <summary>
        /// 删除角色的同时删除用户与角色关系表的角色（用于分配角色）
        /// </summary>
        /// <param name="uinr"></param>
        /// <returns></returns>
        public bool DelRole(List<UserInRoleModel> uinr) 
        {
            try
            {
                if (uinr != null)
                {
                    foreach (var item in uinr)
                    {
                        var entity = _context.UserInRoles.SingleOrDefault(p => p.UsId == item.UsId && p.RlId == item.RlId);
                        _context.UserInRoles.Remove(entity);
                        _context.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-DelRole", e);
            }
            return false;
        }

        /// <summary>
        /// 根据id获取关系表单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserInRoleModel> GetURRelationInfoById(long id)
        {
            try
            {
                var list = _context.UserInRoles.Where(p => p.RlId == id).Select(p =>
                new UserInRoleModel
                {
                    RlId = p.RlId.Value,
                    UsId = p.UsId.Value,
                    UrId = p.UrId
                });
                return list.ToList();
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("RoleService-GetURRelationInfoById", e);
            }
            return null;
        }
    }
}
