using Microsoft.AspNetCore.Mvc;

namespace HR_Management.Presentation.Hatoeas;

public class LinkBuilder
{
    private readonly IUrlHelper _urlHelper;

    public LinkBuilder(IUrlHelper urlHelper)
    {
        _urlHelper = urlHelper;
    }

    public List<Link> BuildLink(int id)
    {
        return new List<Link>
        {
            new Link { Href = _urlHelper.Action("Get", "LeaveType", new { id })!, Method = "GET", Rel= "Self"},
            new Link { Href= _urlHelper.Action("Get", "LeaveType")!, Method = "GET", Rel= "All" },
            new Link { Href= _urlHelper.Action("Post", "LeaveType")!, Method = "POST", Rel= "Create" },
            new Link { Href= _urlHelper.Action("Put", "LeaveType", new { id })!, Method = "PUT", Rel= "Update" },
            new Link { Href = _urlHelper.Action("Delete", "LeaveType", new { id })!, Method = "DELETE", Rel= "Delete" }
        };
    }
}
