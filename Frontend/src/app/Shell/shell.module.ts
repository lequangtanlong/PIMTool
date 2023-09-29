import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { PIMBaseModule } from '../Base/base.module';
import { ShellComponent } from './components/shell/shell.component';
import { SideBarComponent } from './components/side-bar/side-bar.component';

@NgModule({
    declarations: [
        ShellComponent,
        SideBarComponent
    ],
    imports: [
        RouterModule,
        PIMBaseModule
    ]
})
export class ShellModule {

}
