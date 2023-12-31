import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProjectListComponent } from './components';
import { NewProjectComponent } from './components/new-project/new-project.component';

const routes: Routes = [
    { path: '', component: ProjectListComponent},
    { path: 'list', component: ProjectListComponent},
    { path: 'new', component: NewProjectComponent},
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProjectRoutingModule {
}
