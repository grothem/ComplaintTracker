import { CitizenComplaintTrackerPage } from './app.po';

describe('citizen-complaint-tracker App', () => {
  let page: CitizenComplaintTrackerPage;

  beforeEach(() => {
    page = new CitizenComplaintTrackerPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
