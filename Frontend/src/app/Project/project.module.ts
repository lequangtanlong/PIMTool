import { NgModule } from '@angular/core';

import { PIMBaseModule } from '@base';
import { ProjectListComponent } from './components';
import { ProjectRoutingModule } from './project-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewProjectComponent } from './components/new-project/new-project.component';

@NgModule({
    declarations: [ProjectListComponent, NewProjectComponent],
    providers: [],
    imports: [
        ProjectRoutingModule, 
        PIMBaseModule,
        FormsModule,
        ReactiveFormsModule,
    ]
})
export class ProjectModule {

}
