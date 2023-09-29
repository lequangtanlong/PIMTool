import { ProjectDto } from "../../../swagger/models/project-dto"

export class Project {
    Id: number
    ProjectNumber: number
    Name: string
    Customer: string
    Status: string
    StartDate: Date
    constructor(projectDTO: ProjectDto) {
        this.Id = projectDTO.id;
        this.ProjectNumber = projectDTO.projectNumber;
        this.Name = projectDTO.name;
        this.Customer = projectDTO.customer;

        if (projectDTO.status == ("NEW"))
            this.Status = 'New';
        else if (projectDTO.status == ("PLA"))
            this.Status = 'Planned';
        else if (projectDTO.status == ("INP"))
            this.Status = 'In progress';
        else if (projectDTO.status == ("FIN"))
            this.Status = 'Finished';

        this.StartDate = new Date(projectDTO.startDate);
    }
}