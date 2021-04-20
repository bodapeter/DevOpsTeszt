import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { GreetingDto } from '../models/greetingDto';
import { GreetingsService } from '../services/greetings-service.service';
import { MatDialog } from '@angular/material/dialog';
import { GreetingDialogComponent } from '../modals/greeting-dialog/greeting-dialog.component';
import { GreetingCreateDto } from '../models/greetingCreateDto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-greetings',
  templateUrl: './greetings.component.html',
  styleUrls: ['./greetings.component.scss']
})
export class GreetingsComponent implements OnInit {
  greetings$: Observable<GreetingDto[]>;

  constructor(private greetingsService: GreetingsService, public dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.loadGreetings();
  }

  loadGreetings() {
    this.greetings$ = this.greetingsService.getGreetings();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(GreetingDialogComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) {
        return;
      }
      this.greetingsService.sendGreeting(new GreetingCreateDto(result)).subscribe((data) => {
        this.snackBar.open(data, 'close', {
          duration: 5000,
        });
        this.loadGreetings();
      });
    });
  }
}
