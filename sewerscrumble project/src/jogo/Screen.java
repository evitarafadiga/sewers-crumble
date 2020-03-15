package jogo;

import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JPanel;
import javax.swing.Timer;

public class Screen extends JPanel implements ActionListener, KeyListener{
	
	Timer t = new Timer(4,this);
	
	//Thread t = new Thread();
	
	Player p = new Player(32,32,32,32,0,0);
	
	public Screen() {
		addKeyListener(this);
		setFocusable(true);
		
		t.start();
		
	}
	
	
	public void actionPerformed(ActionEvent arg0) {
		
		p.tick();
		
		repaint();
	}
	
	public void paint(Graphics g) {
		g.clearRect(0, 0, getWidth(), getHeight());
		
		p.draw(g);
		
	}
	
	public void keyPressed(KeyEvent k) {
		
		switch(k.getKeyCode()) {
		case KeyEvent.VK_D:
			p.setDx(1);
			break;
		case KeyEvent.VK_S:
			p.setDy(1);
			break;
		case KeyEvent.VK_A:
			p.setDx(-1);
			break;
		case KeyEvent.VK_W:
			p.setDy(-1);
			break;
		case KeyEvent.VK_RIGHT:
			p.setDx(1);
			break;
		case KeyEvent.VK_DOWN:
			p.setDy(1);
			break;
		case KeyEvent.VK_LEFT:
			p.setDx(-1);
			break;
		case KeyEvent.VK_UP:
			p.setDy(-1);
			break;
		}
		
		
	}

	
	public void keyReleased(KeyEvent r) {
		
		switch(r.getKeyCode()) {
		case KeyEvent.VK_D:
			p.setDx(0);
			break;
		case KeyEvent.VK_S:
			p.setDy(0);
			break;
		case KeyEvent.VK_A:
			p.setDx(0);
			break;
		case KeyEvent.VK_W:
			p.setDy(0);
			break;
		case KeyEvent.VK_RIGHT:
			p.setDx(0);
			break;
		case KeyEvent.VK_DOWN:
			p.setDy(0);
			break;
		case KeyEvent.VK_LEFT:
			p.setDx(0);
			break;
		case KeyEvent.VK_UP:
			p.setDy(0);
			break;
		}
	}

	
	public void keyTyped(KeyEvent specialpower) {
		
		switch(specialpower.getKeyCode()) {
		case KeyEvent.VK_E:
			p.dig();
			break;
		case KeyEvent.VK_R:
			p.stamina();
			break;
		}
		
	}


}
