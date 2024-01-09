import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { TimeagoModule } from 'ngx-timeago';
import { Message } from 'src/app/_models/message';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-member-message',
  standalone: true,
  templateUrl: './member-message.component.html',
  styleUrls: ['./member-message.component.css'],
  imports: [CommonModule, TimeagoModule, FormsModule]
})
export class MemberMessageComponent implements OnInit {
  @ViewChild('messageForm')messageForm?:NgForm
  @Input() username?: string;
  messageContent = '';


  constructor(public messageService:MessageService) { }

  ngOnInit(): void {

  }

  sendMessage(){
    if(!this.username) return;
    this.messageService.sendMessages(this.username, this.messageContent).then(() =>{
      this.messageForm?.reset();
    })

  }



}
