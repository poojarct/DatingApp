import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';
import { TabDirective, TabsModule, TabsetComponent } from 'ngx-bootstrap/tabs';
import { TimeagoModule } from 'ngx-timeago';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { MemberMessageComponent } from '../member-message/member-message.component';
import { MessageService } from 'src/app/_services/message.service';
import { Message } from 'src/app/_models/message';

@Component({
  selector: 'app-member-detail',
  standalone: true,
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
  imports: [CommonModule, TabsModule, GalleryModule,TimeagoModule, MemberMessageComponent]
})
export class MemberDetailComponent implements OnInit {
  @ViewChild('memberTabs', { static: true }) memberTabs?: TabsetComponent;
 member: Member = {} as Member;
 images: GalleryItem [] = [];
 activeTab?: TabDirective;
 messages: Message[] = [];

 constructor(private memberservice: MembersService, private route: ActivatedRoute, private messageService:MessageService){}

  ngOnInit(): void {
    this.route.data.subscribe({
      next: data => this.member = data['member']
    })

    this.route.queryParams.subscribe({
      next: params => {
        params['tab'] && this.selectTab(params['tab'])
      }
    })

    this.getImages()
  }

  onTabActivated(data: TabDirective) {
    this.activeTab = data;
    if (this.activeTab.heading === 'Messages') {
      this.loadMessages();
      //this.messageService.createHubConnection(this.user, this.member.userName);
    } else {
      //this.messageService.stopHubConnection();
    }
  }


  loadMessages() {
    if (this.member) {
      this.messageService.getMessageThread(this.member.userName).subscribe({
        next: messages => this.messages = messages
      })
    }
  }

  selectTab(heading: string){
    if(this.memberTabs) {
      this.memberTabs.tabs.find(x =>x.heading == heading)!.active = true;
    }
  }

  

  getImages(){
    if(!this.member)return;
    for (const photo of this.member?.photos){
      this.images.push(new ImageItem({src: photo.url, thumb:photo.url}));
    }
  }

}
