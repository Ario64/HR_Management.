using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Presentation.Hatoeas;

public class LinkBuilder<T> where T : class
{
    private readonly IUrlHelper _urlHelper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string controllerName = typeof(T).Name.Replace("Controller", "");
    private readonly string? _schema;

    public LinkBuilder(IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor)
    {
        _urlHelper = urlHelper;
        _httpContextAccessor = httpContextAccessor;
        _schema = _httpContextAccessor.HttpContext?.Request.Scheme;
    }

    //Links for get all
    public List<Link> BuildLinkForList(int id)
    {
        return new List<Link>
        {
            new() { Href = _urlHelper.Action("Get", controllerName , new { id }, _schema)!, Method = "GET", Rel= "Self"},
            new () { Href= _urlHelper.Action("Get", controllerName,null, _schema)!, Method = "GET", Rel= "All" },
            new () { Href= _urlHelper.Action("Post", controllerName, null, _schema)!, Method = "POST", Rel= "Create" },
            new () { Href= _urlHelper.Action("Put", controllerName, new { id }, _schema)!, Method = "PUT", Rel= "Update" },
            new () { Href = _urlHelper.Action("Delete", controllerName, new { id }, _schema)!, Method = "DELETE", Rel= "Delete" }
        };
    }

    //Links for get single item
    public List<Link> BuildLinkForItem(int id)
    {
        return new List<Link>
        {
            new() { Href = _urlHelper.Action("Post", controllerName, null, _schema)!, Method = "POST", Rel = "Create" },
            new() { Href = _urlHelper.Action("Put", controllerName, new { id }, _schema)!, Method = "PUT", Rel = "Update" },
            new() { Href = _urlHelper.Action("Delete", controllerName, new { id }, _schema)!, Method = "DELETE", Rel = "Delete" }
        };
    }

    //Links for after create
    public List<Link> BuildLinkAfterCreate(int id)
    {
        return BuildLinkForItem(id);
    }

    //Links for after update
    public List<Link> BuildLinkAfterUpdate(int id)
    {
        return BuildLinkForItem(id);
    }

    //Links for after delete
    public List<Link> BuildLinkAfterDelete()
    {
        return new List<Link>
        {
            new() { Href = _urlHelper.Action("Get", controllerName, null, _schema)!, Method = "GET", Rel = "All" },
            new() { Href = _urlHelper.Action("Post", controllerName, null, _schema)!, Method = "POST", Rel = "Create" }
        };
    }

}
