import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { ProjectService } from '../../swagger/services/project.service';
import { Project } from './dom/project-dom';
import { map } from 'rxjs/operators'
import { ProjectDto } from '../../swagger/models/project-dto';
import { Observable, of } from 'rxjs';
import { Status } from './dom/project-status-dom'

@Injectable({
    providedIn: 'root'
})
export class ProjectServices {
    constructor(private projectService: ProjectService, private http: HttpClient) { }

    getProjectsList(): Observable<Array<Project>> {
        return this.projectService.ProjectGet().pipe(
            map((data) => {
                let listProject: Project[] = [];
                for (let pro of data) {
                    listProject.push(new Project(pro as ProjectDto));
                }
                return listProject;
            })
        )
    }

    findStatuses(): Observable<Status[]> {
        return this.http.get<Status[]>("https://localhost:5001/api/Status");
    }

    getProjectsListWithKeySearch(keySearch, status): Observable<Project[]> {
        return this.projectService.ProjectGetWithKeySearch({ input: keySearch, status: status }).pipe(
            map((data) => {
                let listProject: Project[] = [];
                for (let pro of data) {
                    listProject.push(new Project(pro as ProjectDto));
                }
                return listProject;
            })
        )
    }

    getProjectDetail(id: number) {
        return this.projectService.ProjectGet_1(id);
    }

    deleteProjects(ids): Observable<null> {
        return this.projectService.ProjectMultipleDelete(ids);
    }
}