import { Component, ElementRef, ChangeDetectionStrategy, OnInit, ViewChild, ChangeDetectorRef, Output, EventEmitter } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { Observable, of } from 'rxjs';
import { filter } from 'rxjs/operators';
import { Project } from '../../services/dom/project-dom'
import { Status } from '../../services/dom/project-status-dom'
import { ProjectServices } from '../../services/index'

import { from } from 'rxjs';

@Component({
    selector: 'pim-project-list',
    styleUrls: ['./project-list.component.scss'],
    templateUrl: './project-list.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProjectListComponent implements OnInit {
    projectsListForm: FormGroup
    keySearch: string = ""
    status: number = -1

    projectsList$: Observable<Project[]>
    statusList: Status[] = []

    selectedProjectsList: Project[] = []

    @ViewChild('searchForm', { static: false }) searchForm: NgForm

    @Output() title: EventEmitter<any> = new EventEmitter()

    constructor(
        public projectServices: ProjectServices,
        private changeDetectorRef: ChangeDetectorRef,
        private translateService: TranslateService
    ) { }

    ngOnInit(): void {
        this.getAllStatuses();

        this.getAllProjects()
    }

    onSubmit(): void {
        console.log(this.keySearch)
        console.log(this.status)

        this.projectServices.getProjectsListWithKeySearch(this.keySearch, this.status).subscribe(data => {
            this.projectsList$ = of(data);
            this.changeDetectorRef.markForCheck();
        });
    }

    resetForm(): void {
        this.keySearch = ""
        this.status = -1
        this.getAllProjects()

        this.changeDetectorRef.markForCheck()
    }

    getAllStatuses(): void {
        this.projectServices.findStatuses().subscribe(data => {
            this.statusList = data;
            this.changeDetectorRef.markForCheck();
        })
    }

    getAllProjects(): void {
        this.projectServices.getProjectsList().subscribe(data => {
            this.projectsList$ = of(data);
            this.changeDetectorRef.markForCheck();
        })
    }

    changeStatus(e): void {
        this.status = e.target["selectedIndex"] - 1;
    }

    selectProject(event: any, project: Project): void {
        this.selectedProjectsList = this.selectedProjectsList.filter(element => element.Id != project.Id)

        if (event.target.checked) {
            this.selectedProjectsList.push(project);
        }
    }

    onDeleteSelectedProject(id: number) {
        // this.projectServices.getProjectDetail(id).subscribe(data => {
        //     if (data.status == 'NEW') {
        //         this.projectServices.deleteProjects([id]).subscribe(() => {
        //             this.getAllProjects();
        //         });
        //     }
        //     else {
                
        //     }
        // })

        console.log(id)

        this.projectServices.deleteProjects([id]).subscribe(() => {
            this.getAllProjects();
        });
        
    }

    onDeleteSelectedProjects() {
        let checkedDeletedProjects = this.selectedProjectsList.filter(x => x.Status != 'New');
        if (checkedDeletedProjects.length == 0) {
            let checkedDeletedIds = this.selectedProjectsList.map(x => x.Id);
            this.projectServices.deleteProjects(checkedDeletedIds).subscribe(() => {
                this.getAllProjects();
            });
            this.selectedProjectsList = [];

            // notify
        }
        else {
            // notify
        }
    }
}
