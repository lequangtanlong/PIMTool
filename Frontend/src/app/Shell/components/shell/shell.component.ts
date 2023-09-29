import { Component, ChangeDetectionStrategy, ChangeDetectorRef, AfterContentChecked } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'pim-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ShellComponent implements AfterContentChecked {
  isDefaultLang: boolean = true // Default Language: English
  
  constructor(public translateService: TranslateService, private changeDetectorRef: ChangeDetectorRef) {
    translateService.addLangs(['en', 'fr'])
    translateService.setDefaultLang('en')
  }

  ngAfterContentChecked(): void {
    this.changeDetectorRef.markForCheck()
  }

  selectEnglish(): void {
    this.translateService.use('en')
    this.isDefaultLang = true
  }

  selectFrench(): void {
    this.translateService.use('fr')
    this.isDefaultLang = false
  }
}
