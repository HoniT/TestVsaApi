using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace src.Features.Files.Download
{
    public record FileDownloadCommand(string fileName)
        : IRequest<IResult>;
}