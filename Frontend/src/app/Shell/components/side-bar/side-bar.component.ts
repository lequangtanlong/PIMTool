import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss']
})
export class SideBarComponent implements OnInit {

  constructor(private router: Router, private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit(): void {
  }

  selection: string = ""

  ngAfterContentChecked(): void {
    this.changeDetectorRef.markForCheck()
  }

  onActive(component): void {
    component.title.subscribe(data => {
      this.selection = data
    })
  }

  backToList(): void {
    this.router.navigate(['project/list'])
  }

}
