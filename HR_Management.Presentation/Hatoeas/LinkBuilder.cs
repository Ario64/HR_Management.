using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace HR_Management.Presentation.Hatoeas;

public class LinkBuilder
{
    private readonly IUrlHelper _urlHelper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LinkBuilder(IUrlHelper urlHelper, IHttpContextAccessor httpContextAccessor)
    {
        _urlHelper = urlHelper;
        _httpContextAccessor = httpContextAccessor;
    }

    //Links for get all
    public List<Link> BuildLinkForList(int id)
    {
        var schema = _httpContextAccessor.HttpContext?.Request.Scheme;

        return new List<Link>
        {
            new Link { Href = _urlHelper.Action("Get", "LeaveType", new { id }, schema)!, Method = "GET", Rel= "Self"},
            new Link { Href= _urlHelper.Action("Get", "LeaveType")!, Method = "GET", Rel= "All" },
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" },
            new Link { Href= _urlHelper.Action("Put", "LeaveType", new { id })!, Method = "PUT", Rel= "Update" },
            new Link { Href = _urlHelper.Action("Delete", "LeaveType", new { id })!, Method = "DELETE", Rel= "Delete" }
        };
    }

    //Links for get single item
    public List<Link> BuildLinkForItem(int id)
    {
        return new List<Link>
        {
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" },
            new Link { Href= _urlHelper.Action("Put", "LeaveType", new { id })!, Method = "PUT", Rel= "Update" },
            new Link { Href = _urlHelper.Action("Delete", "LeaveType", new { id })!, Method = "DELETE", Rel= "Delete" }
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
            new Link { Href= _urlHelper.Action("Get", "LeaveType")!, Method = "GET", Rel= "All" },
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" }
        };
    }
}
